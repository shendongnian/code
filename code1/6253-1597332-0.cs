    namespace CMessWin05
    {
        public class EventSuppressor
        {
            Control _source;
            EventHandlerList _sourceEventHandlerList;
            FieldInfo _headFI;
            Dictionary<object, Delegate[]> _handlers;
            PropertyInfo _sourceEventsInfo;
            Type _eventHandlerListType;
            Type _sourceType;
            
    
            public EventSuppressor(Control control)
            {
                if (control == null)
                    throw new ArgumentNullException("control", "An instance of a control must be provided.");
    
                _source = control;
                _sourceType = _source.GetType();
                _sourceEventsInfo = _sourceType.GetProperty("Events", BindingFlags.Instance | BindingFlags.NonPublic);
                _sourceEventHandlerList = (EventHandlerList)_sourceEventsInfo.GetValue(_source, null);
                _eventHandlerListType = _sourceEventHandlerList.GetType();
                _headFI = _eventHandlerListType.GetField("head", BindingFlags.Instance | BindingFlags.NonPublic);
            }
    
            private void BuildList()
            {
                _handlers = new Dictionary<object, Delegate[]>();
                object head = _headFI.GetValue(_sourceEventHandlerList);
                if (head != null)
                {
                    Type listEntryType = head.GetType();
                    FieldInfo delegateFI = listEntryType.GetField("handler", BindingFlags.Instance | BindingFlags.NonPublic);
                    FieldInfo keyFI = listEntryType.GetField("key", BindingFlags.Instance | BindingFlags.NonPublic);
                    FieldInfo nextFI = listEntryType.GetField("next", BindingFlags.Instance | BindingFlags.NonPublic);
                    BuildListWalk(head, delegateFI, keyFI, nextFI);
                }
            }
    
            private void BuildListWalk(object entry, FieldInfo delegateFI, FieldInfo keyFI, FieldInfo nextFI)
            {
                if (entry != null)
                {
                    Delegate dele = (Delegate)delegateFI.GetValue(entry);
                    object key = keyFI.GetValue(entry);
                    object next = nextFI.GetValue(entry);
    
                    Delegate[] listeners = dele.GetInvocationList();
                    if(listeners != null && listeners.Length > 0)
                        _handlers.Add(key, listeners);
    
                    if (next != null)
                    {
                        BuildListWalk(next, delegateFI, keyFI, nextFI);
                    }
                }
            }
    
            public void Resume()
            {
                if (_handlers == null)
                    throw new ApplicationException("Events have not been suppressed.");
    
                foreach (KeyValuePair<object, Delegate[]> pair in _handlers)
                {
                    for (int x = 0; x < pair.Value.Length; x++)
                        _sourceEventHandlerList.AddHandler(pair.Key, pair.Value[x]);
                }
    
                _handlers = null;
            }
    
            public void Suppress()
            {
                if (_handlers != null)
                    throw new ApplicationException("Events are already being suppressed.");
    
                BuildList();
                
                foreach (KeyValuePair<object, Delegate[]> pair in _handlers)
                {
                    for (int x = pair.Value.Length - 1; x >= 0; x--)
                        _sourceEventHandlerList.RemoveHandler(pair.Key, pair.Value[x]);
                }
            }
     
        }
    }
