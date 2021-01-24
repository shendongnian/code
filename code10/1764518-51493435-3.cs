    Rootobject chatEvent = JsonConvert.DeserializeObject<Rootobject>(jsonStr);
    
                List<int> agent_message_ids = new List<int>();
                List<int> visitior_message_ids = new List<int>();
    
                foreach (Event e in chatEvent.events)
                {
                    if (e.user_type == UserType.agent.ToString())
                    {
                        agent_message_ids.Add(e.message_id);
                    }
    
                    if (e.user_type == UserType.visitor.ToString())
                    {
                        visitior_message_ids.Add(e.message_id);
                    }
    
                }
