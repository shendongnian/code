    var resources = 
        new System.ComponentModel.ComponentResourceManager(typeof(Form1));
    button1.Image = (Image)resources.GetObject("button1.Image");
    button2.Image = (Image)resources.GetObject(button2.Name + ".Image");
    ...
