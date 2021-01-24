     using (var img = Image.Load("fb.jpg"))
     {
         using (Image<Rgba32> destRound = img.Clone(x => x.ConvertToAvatar(new Size(200, 200), 100)))
         {
             destRound.Save("output/fb-round.png");
         }
     }
