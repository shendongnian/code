    public void OnClick(View v)
        {
           if(v.Id == Resource.Id.share_butn){
             int position = （int）v.Tag；
             Intent intentsend = new Intent();
                         intentsend.SetAction(Intent.ActionSend);
                        intentsend.PutExtra(Intent.ExtraText,item[position].title+"\n"+item[position].main+"\n"+item[position].history);
                        intentsend.SetType("text/plain");
                        context.StartActivity(intentsend);
           }
           if(v.Id == Resource.Id.button1){
             var button = v as Button;
            int count = int.Parse(button.Text) - 1;
            //new two line under this:
            button.Text = count.ToString();
            if (count < 0)
            {
                count = 0;
                button.Clickable = false;
            }
            button.Text = count.ToString();
           }
           
        }
