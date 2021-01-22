    [MongoIgnore]
    public virtual string FullInfos
        {
            get
            {
                var html = Contact1Info;
                html += Contact2Info;
                return html;
            }
        }
