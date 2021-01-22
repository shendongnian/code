// Assume pic is the type of PictureBox and the image property is assigned
PictureBox pic;
// And that the picturebox is embedded in the Panel variable p.
p.Controls.Add(pic);
// ...
// So why not do this?
pic.Image.Save(...); 
