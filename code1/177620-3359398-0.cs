    public class CustomBulletedList : BulletedList
    {
        protected override void Render(HtmlTextWriter writer)
        {
            var sb = new StringBuilder();
            var sw = new StringWriter(sb);
            var htmlWriter = new HtmlTextWriter(sw);
            base.Render(htmlWriter);
            sb = sb.Replace("&lt;div class=notes&gt;", "<div class=notes>");
            sb = sb.Replace("&lt;/div&gt;", "</div>");
            writer.Write(sb.ToString());
        }
    }
