    ...
    catch (WebException e)
    {
        if (e.Response != null && (e.Response as HttpWebResponse).StatusCode == HttpStatusCode.NotFound)
        {
            var Html404Page = new StreamReader(e.Response.GetResponseStream()).ReadToEnd().ToString();
        }
    }
