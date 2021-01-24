    @model List<EventGalleryViewModel>
    @{
    ViewBag.Title = "Gellery";
    }
    <br /><br /><br />
    <h2>Gellery</h2>
    
    
    @foreach (var item in Model)
    {
      <a href='@Url.Content("~/GalleryImages/" + item.ThumbImage)'>
          <img class='thumbnail' src='@Url.Content("~/GalleryImages/" + item.ThumbImage)' />
    </a>
    
    }
