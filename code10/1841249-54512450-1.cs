    public void OnClick(View v)
        {
           if(v.Id == Resource.Id.share_butn){
            var imageView = v as ImageView;
             //doing something ，if click sharebutton then startActivity，add code here
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
