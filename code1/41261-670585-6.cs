    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.InteropServices;
    using COM = System.Runtime.InteropServices.ComTypes;
    namespace YourNamespaceHere
    {
    /// <summary>
    /// A utility class for dealing with COM events.
    /// Needs error-handling and could potentially be refactored
    /// into a regular class. Also, I haven't extensively tested this code;
    /// there may be a memory leak somewhere due to the rather
    /// low-level stuff going on in the class, but I think I covered everything.
    /// </summary>
    public static class ComEventUtils
    {
        /// <summary>
        /// Get a list of all objects implementing an event sink interface T
        /// that are listening for events on a specified COM object.
        /// </summary>
        /// <typeparam name="T">The event sink interface.</typeparam>
        /// <param name="comObject">The COM object whose event sinks you want to retrieve.</param>
        /// <returns>A List of objects that implement the given event sink interface and which
        /// are actively listening for events from the specified COM object.</returns>
        public static List<T> GetEventSinks<T>(object comObject)
        {
            List<T> sinks = new List<T>();
            List<COM.IConnectionPoint> connectionPoints = GetConnectionPoints(comObject);
            // Loop through the source object's connection points, 
            // find the objects that are listening for events at each connection point,
            // and add the objects we are interested in to the list.
            foreach(COM.IConnectionPoint connectionPoint in connectionPoints)
            {
                List<COM.CONNECTDATA> connections = GetConnectionData(connectionPoint);
                foreach (COM.CONNECTDATA connection in connections)
                {
                    object candidate = connection.pUnk;
                    // I tried to avoid relying on try/catch for this
                    // part, but candidate.GetType().GetInterfaces() kept
                    // returning an empty array.
                    try
                    {
                        sinks.Add((T)candidate);
                    }
                    catch { }
                }
                // Need to release the interface pointer in each CONNECTDATA instance
                // because GetConnectionData implicitly AddRef's it.
                foreach (COM.CONNECTDATA connection in connections)
                {
                    Marshal.ReleaseComObject(connection.pUnk);
                }
            }
            return sinks;
        }
        /// <summary>
        /// Get all the event connection points for a given COM object.
        /// </summary>
        /// <param name="comObject">A COM object that raises events.</param>
        /// <returns>A List of IConnectionPoint instances for the COM object.</returns>
        private static List<COM.IConnectionPoint> GetConnectionPoints(object comObject)
        {
            COM.IConnectionPointContainer connectionPointContainer = (COM.IConnectionPointContainer)comObject;
            COM.IEnumConnectionPoints enumConnectionPoints;
            COM.IConnectionPoint[] oneConnectionPoint = new COM.IConnectionPoint[1];
            List<COM.IConnectionPoint> connectionPoints = new List<COM.IConnectionPoint>();
            connectionPointContainer.EnumConnectionPoints(out enumConnectionPoints);
            enumConnectionPoints.Reset();
            int fetchCount = 0;
            SafeIntPtr pFetchCount = new SafeIntPtr();
            do
            {
                if (0 != enumConnectionPoints.Next(1, oneConnectionPoint, pFetchCount.ToIntPtr()))
                {
                    break;
                }
                fetchCount = pFetchCount.Value;
                if (fetchCount > 0)
                    connectionPoints.Add(oneConnectionPoint[0]);
            } while (fetchCount > 0);
            pFetchCount.Dispose();
            return connectionPoints;
        }
        /// <summary>
        /// Returns a list of CONNECTDATA instances representing the current
        /// event sink connections to the given IConnectionPoint.
        /// </summary>
        /// <param name="connectionPoint">The IConnectionPoint to return connection data for.</param>
        /// <returns>A List of CONNECTDATA instances representing all the current event sink connections to the 
        /// given connection point.</returns>
        private static List<COM.CONNECTDATA> GetConnectionData(COM.IConnectionPoint connectionPoint)
        {
            COM.IEnumConnections enumConnections;
            COM.CONNECTDATA[] oneConnectData = new COM.CONNECTDATA[1];
            List<COM.CONNECTDATA> connectDataObjects = new List<COM.CONNECTDATA>();
            connectionPoint.EnumConnections(out enumConnections);
            enumConnections.Reset();
            int fetchCount = 0;
            SafeIntPtr pFetchCount = new SafeIntPtr();
            do
            {
                if (0 != enumConnections.Next(1, oneConnectData, pFetchCount.ToIntPtr()))
                {
                    break;
                }
                fetchCount = pFetchCount.Value;
                if (fetchCount > 0)
                    connectDataObjects.Add(oneConnectData[0]);
            } while (fetchCount > 0);
            pFetchCount.Dispose();
            return connectDataObjects;
        }
    } //end class ComEventUtils
    /// <summary>
    /// A simple wrapper class around an IntPtr that
    /// manages its own memory.
    /// </summary>
    public class SafeIntPtr : IDisposable
    {
        private bool _disposed = false;
        private IntPtr _pInt = IntPtr.Zero;
        /// <summary>
        /// Allocates storage for an int and assigns it to this pointer.
        /// The pointed-to value defaults to 0.
        /// </summary>
        public SafeIntPtr()
            : this(0)
        {
            //
        }
        /// <summary>
        /// Allocates storage for an int, assigns it to this pointer,
        /// and initializes the pointed-to memory to known value.
        /// <param name="value">The value this that this <tt>SafeIntPtr</tt> points to initially.</param>
        /// </summary>
        public SafeIntPtr(int value)
        {
            _pInt = Marshal.AllocHGlobal(sizeof(int));
            this.Value = value;
        }
        /// <summary>
        /// Gets or sets the value this pointer is pointing to.
        /// </summary>
        public int Value
        {
            get 
            {
                if (_disposed)
                    throw new InvalidOperationException("This pointer has been disposed.");
                return Marshal.ReadInt32(_pInt); 
            }
            set 
            {
                if (_disposed)
                    throw new InvalidOperationException("This pointer has been disposed.");
                Marshal.WriteInt32(_pInt, Value); 
            }
        }
        /// <summary>
        /// Returns an IntPtr representation of this SafeIntPtr.
        /// </summary>
        /// <returns></returns>
        public IntPtr ToIntPtr()
        {
            return _pInt;
        }
        /// <summary>
        /// Deallocates the memory for this pointer.
        /// </summary>
        public void Dispose()
        {
            if (!_disposed)
            {
                Marshal.FreeHGlobal(_pInt);
                _disposed = true;
            }
        }
        ~SafeIntPtr()
        {
            if (!_disposed)
                Dispose();
        }
    } //end class SafeIntPtr
    } //end namespace YourNamespaceHere
