     int[] array = new int[400];
                for (int i = 0; i < Session.Count; i++)
                {
                    var crntSession = Session.Keys[i];
                    lstbx.Items.Add(crntSession + "=" + Session[crntSession] + "<br />");
                }
