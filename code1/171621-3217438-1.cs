    // the below adds embedded images an email...
      AlternateView avHtml = AlternateView.CreateAlternateViewFromString(
          _body, null, System.Net.Mime.MediaTypeNames.Text.Html);
      LinkedResource pic = new LinkedResource("\path\to\file\to\embed\here", System.Net.Mime.MediaTypeNames.Image.Jpeg);
      pic.ContentId = "IMAGE1"; // just make sure this is a unique string if you have > 1
      avHtml.LinkedResources.Add(pic);
      m.AlternateViews.Add(avHtml);
