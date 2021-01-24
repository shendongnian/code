    public String getMimeType(Uri uri) {
        String mimeType = null;
        if (uri.Scheme.Equals(ContentResolver.SchemeContent))
        {
            ContentResolver cr = Application.Context.ContentResolver;
            mimeType = cr.GetType(uri);
        }
        else
        {
            String fileExtension = MimeTypeMap.GetFileExtensionFromUrl(uri.ToString());
            mimeType = MimeTypeMap.Singleton.GetMimeTypeFromExtension(
            fileExtension.ToLower());
        }
        return mimeType;
    }
