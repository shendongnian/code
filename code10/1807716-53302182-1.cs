    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.SignalR;
    using SignalRServer.API.Services;
    namespace SignalRServer.API.Hubs
    {
    [Authorize]
    public class NewsHub : Hub
    {
    private readonly NewsService newsService;
    private readonly HubConnectionsStorage connectionsStorage;
    public NewsHub(NewsService newsService, HubConnectionsStorage connectionsStorage)
    {
      this.newsService = newsService;
      this.connectionsStorage = connectionsStorage;
    }
    public override Task OnConnectedAsync()
    {
      var jwtToken = GetCurrentConnectionJwtToken();
      connectionsStorage.AddConnection(Context.ConnectionId, jwtToken);
      return Task.CompletedTask;
    }
    public override Task OnDisconnectedAsync(Exception exception)
    {
      connectionsStorage.RemoveConnection(Context.ConnectionId);
      return Task.CompletedTask;
    }
       
    public async Task Send((string groupName, string generatedNews) news)
    {
      if (!newsService.CheckTopic(news.groupName))
        throw new Exception("cannot send a news item to a group which does not exist.");
      
      connectionsStorage.RemoveExpiredConnections(ValidateJwtToken);
      var groupConnections = connectionsStorage.GetGroupConnections(news.groupName);
      await Clients.Clients(groupConnections).SendAsync("NewsFeed", news.generatedNews);
    }
    public async Task JoinGroup(string groupName)
    {
      if (!newsService.CheckTopic(groupName))
        throw new Exception("cannot join a group which does not exist.");
      
      connectionsStorage.AddConnectionToGroup(Context.ConnectionId, groupName);
      var groupConnections = connectionsStorage.GetGroupConnections(groupName);
      
      await Clients.Clients(groupConnections).SendAsync("JoinGroup", groupName);
      var history = newsService.GetTopicNews(groupName);
      await Clients.Client(Context.ConnectionId).SendAsync("History", history);
    }
    public async Task LeaveGroup(string groupName)
    {
      if (!newsService.CheckTopic(groupName))
        throw new Exception("cannot leave a group which does not exist.");
      var groupConnections = connectionsStorage.GetGroupConnections(groupName);
      await Clients.Clients(groupConnections).SendAsync("LeaveGroup", groupName);
      connectionsStorage.RemoveConnectionFromGroup(Context.ConnectionId, groupName);
    }
    
    private string GetCurrentConnectionJwtToken() => "fake jwt token "+Random.Next(4);
    private bool ValidateJwtToken(string jwtToken) => Random.NextDouble() >= 0.5;
    
    private static readonly Random Random = new Random();
    }
    }
