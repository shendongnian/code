     private Video SetAccessControl(Video video, string type, string permission)
        {
            var exts = video.YouTubeEntry
                .ExtensionElements
                .Where(x => x is XmlExtension)
                .Select(x => x as XmlExtension)
                .Where(x => x.Node.Attributes["action"] != null && x.Node.Attributes["action"].InnerText == type);
            var ext = exts.FirstOrDefault();
            if (ext != null)
                ext.Node.Attributes["permission"].InnerText = permission;
            return video;
        }
