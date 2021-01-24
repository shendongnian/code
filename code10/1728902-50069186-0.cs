            Intent intent = Intent;
            String action = Intent.Action;
            String type = intent.Type;
           
            if (Intent.ActionSend.Equals(action) && type != null)
            {
                if ("text/plain".Equals(type))
                {
                    // Handle text being sent
                    // ...
                    // ...
                    // ...     
                    String sharedText = intent.GetStringExtra(Intent.ExtraText);
                }
                else if (type.StartsWith("image/"))
                {
                    // Handle single image being sent
                    // ...
                    // ...
                    // ...    
                }
            }
            else if (Intent.ActionSendMultiple.Equals(action) && type != null)
            {
                if (type.StartsWith("image/"))
                {
                    // Handle multiple images being sent
                    // ...
                    // ...
                    // ...                        
                }
            }
            else
            {
                // Handle other intents, such as being started from the home screen                    
            }
    
