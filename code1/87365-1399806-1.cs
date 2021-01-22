    public partial class MyPage : BasePage {
      protected void Page_Load(object sender, EventArgs e) {
        // Or however you're generating your canonical urls
        string cannonicalUrl = GetCannonicalUrl();
        AddHeaderLink(cannonicalUrl, "canonical", string.Empty, string.Empty);
      }
    }
