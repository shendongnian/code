     protected void HandleBtnClick(object sender, EventArgs args)
            {
                Button btn = sender as Button;
                if(btn==null){ 
                   return; //This is not expected.
                }
                if(btn.Name=="button1")
                {
                    DoFirstTask();
                }
                else if (btn.Name == "button2")
                {
                    DoSecondTask();
                }
                ...
            }
