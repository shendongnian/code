    foreach (SearchResult image in Search.GetImages(componentId)) {
      ContainerMarkup.Controls.Add(
        Tag.Div.CssClass("captionedImage")
        .AddChild(Tag.Image(image.Resolutions[0].Uri).Width(150).Alt(Image.Caption))
        .AddChild(Tag.Paragraph.Text(Image.Caption)));
    }
