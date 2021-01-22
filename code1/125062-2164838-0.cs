        internal List<CodeMemberField> createEventHooks()
        {
            string[] eventNames = new string[] { "OnUpdate()", "OnInsert()", "OnDelete()", "OnSelect()", "OnSelectAll()" };
            List<CodeMemberField> eventHooks = new List<CodeMemberField>();
            foreach (string eventName in eventNames)
            {
                CodeMemberField eventHook = new CodeMemberField(); //do it as a FIELD instead of a METHOD
                eventHook.Name = eventName;
                eventHook.Attributes = MemberAttributes.ScopeMask;
                eventHook.Type = new CodeTypeReference("partial void");
                eventHooks.Add(eventHook);
            }
            return eventHooks;
        }
