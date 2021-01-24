    Rootobject chatEvent = JsonConvert.DeserializeObject<Rootobject>(jsonStr);
    
                List<int> agent_message_ids = new List<int>();
                List<int> visitior_message_ids = new List<int>();
    
                //string agent_message_id = string.Empty;
                //string visitior_message_id = string.Empty;
    
                foreach (Event e in chatEvent.events)
                {
                    if (e.user_type == UserType.agent.ToString())
                    {
                        agent_message_ids.Add(e.message_id);
                        //agent_message_id = e.message_id;
                    }
    
                    if (e.user_type == UserType.visitor.ToString())
                    {
                        visitior_message_ids.Add(e.message_id);
                        //visitior_message_id  = e.message_id;
                    }
    
                }
