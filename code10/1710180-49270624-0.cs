    var mentionedUser = message.MentionedUsers;
            //Using a loop
            foreach(var user in mentionedUser) {
                if(user == client.CurrentUser) {
                    //Do something
                }
            }
            //Or you could do it...
            if(message.Content.Contains("<@YOURID>")) {
                //Do something
            }
