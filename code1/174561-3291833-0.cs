    using SKYPE4COMLib;
    
    namespace Example
    {
        class SkypeExample
        {
            private SkypeClass _skype;
    
            public SkypeExample()
            {
                _skype = new SkypeClass();
                _skype.MessageStatus += OnMessage;
                _skype._ISkypeEvents_Event_AttachmentStatus += OnAttach;
                _skype.Attach(7, false);
            }
    
            private void OnAttach(TAttachmentStatus status)
            {
                // this app was successfully attached to skype
            }
    
            private void OnMessage(ChatMessage pmessage, TChatMessageStatus status)
            {
                // dont do anything if the message is not received (i.e. we are sending a emssage)
                if (status != TChatMessageStatus.cmsReceived)
                    return;
    
                // simple echo service.
                _skype.get_Chat(pmessage.ChatName).SendMessage(pmessage.Body);
            }
    
            public bool MakeFriend(string handle)
            {
                for (int i = 1; i <= _skype.Friends.Count; i++)
                {
                    if (_skype.Friends[i].Handle == handle)
                        return true;
                }
    
                UserCollection collection = _skype.SearchForUsers(handle);
                if (collection.Count >= 1)
                    collection[1].BuddyStatus = TBuddyStatus.budPendingAuthorization;
    
                return false;
            }
        }
    }
