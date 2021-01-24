    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    namespace SignalRServer.API.Hubs
    {
      public class HubConnectionsStorage
      {
        private readonly Dictionary<string, HashSet<string>> _connectionsByJwtToken;
        private readonly Dictionary<string, string> _jwtTokenByConnection;
        private readonly Dictionary<string, HashSet<string>> _connectionsByGroup;
        private readonly Dictionary<string, HashSet<string>> _groupsByConnection;
        private readonly ReaderWriterLockSlim _lock;
        public HubConnectionsStorage()
        {
          _connectionsByJwtToken = new Dictionary<string, HashSet<string>>();
          _jwtTokenByConnection = new Dictionary<string, string>();
          _connectionsByGroup = new Dictionary<string, HashSet<string>>();
          _groupsByConnection = new Dictionary<string, HashSet<string>>();
          _lock = new ReaderWriterLockSlim();
        }
        public void AddConnection(string connectionId, string jwtToken)
        {
          _lock.EnterWriteLock();
          try
          {
            _jwtTokenByConnection[connectionId] = jwtToken;
        
            if (!_connectionsByJwtToken.TryGetValue(jwtToken, out var connections))
              _connectionsByJwtToken[jwtToken] = connections = new HashSet<string>();
            connections.Add(connectionId);
          }
          finally
          {
            _lock.ExitWriteLock();
          }
        }
        public void AddConnectionToGroup(string connectionId, string group)
        {
          _lock.EnterWriteLock();
          try
          {
            if(!_connectionsByGroup.TryGetValue(group, out var connections))
              _connectionsByGroup[group] = connections = new HashSet<string>();
            connections.Add(connectionId);
            if (!_groupsByConnection.TryGetValue(connectionId, out var groups))
              _groupsByConnection[connectionId] = groups = new HashSet<string>();
            groups.Add(group);
          }
          finally
          {
            _lock.ExitWriteLock();
          }
        }
        public void RemoveConnectionFromGroup(string connectionId, string group)
        {
          _lock.EnterWriteLock();
          try
          {
            if (!_connectionsByGroup.TryGetValue(group, out var connections))
              return;
        
            if(!connections.Remove(connectionId))
              return;
            if (connections.Count == 0)
              _connectionsByGroup.Remove(group);
            var groups = _groupsByConnection[connectionId];
            groups.Remove(group);
            if (groups.Count == 0)
              _groupsByConnection.Remove(connectionId);
          }
          finally
          {
            _lock.ExitWriteLock();
          }
        }
        public void RemoveConnection(string connectionId)
        {
          _lock.EnterWriteLock();
          try
          {
            if(!_jwtTokenByConnection.TryGetValue(connectionId, out var jwtToken))
              return;
            _jwtTokenByConnection.Remove(connectionId);
            var jwtConnections = _connectionsByJwtToken[jwtToken];
            jwtConnections.Remove(connectionId);
            if (jwtConnections.Count == 0)
              _connectionsByJwtToken.Remove(jwtToken);
        
            if(!_groupsByConnection.TryGetValue(connectionId, out var groups))
              return;
            foreach (var group in groups)
            {
              var connections = _connectionsByGroup[group];
              connections.Remove(connectionId);
          
              if (connections.Count == 0)
                _connectionsByGroup.Remove(group);
            }
            _groupsByConnection.Remove(connectionId);
          }
          finally
          {
            _lock.ExitWriteLock();
          }
        }
        public List<string> GetGroupConnections(string group)
        {
          _lock.EnterReadLock();
          try
          {
            if (_connectionsByGroup.TryGetValue(group, out var connections))
              return connections.ToList();
        
            return new List<string>();
          }
          finally 
          {
            _lock.ExitReadLock();
          }
        }
        public void RemoveExpiredConnections(Func<string, bool> validateJwtToken)
        {
          _lock.EnterWriteLock();
          try
          {
            foreach (var jwtToken in _connectionsByJwtToken.Keys.ToList())
            {
              var isValid = validateJwtToken(jwtToken);
              if (isValid) 
                continue;
          
              var invalidConnections = _connectionsByJwtToken[jwtToken];
              foreach (var invalidConnection in invalidConnections)
              {
                if (_groupsByConnection.TryGetValue(invalidConnection, out var connectionGroups))
                {
                  foreach (var group in connectionGroups)
                  {
                    var groupConnections = _connectionsByGroup[@group];
                    groupConnections.Remove(invalidConnection);
                    if (groupConnections.Count == 0)
                      _connectionsByGroup.Remove(@group);
                  }
                  _groupsByConnection.Remove(invalidConnection);
                }
                _jwtTokenByConnection.Remove(invalidConnection);
              }
              _connectionsByJwtToken.Remove(jwtToken);
            }
          }
          finally 
          {
            _lock.ExitWriteLock();
          }
        }
      }
    }
