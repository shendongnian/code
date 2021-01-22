    Id(x => x.SystemId);
                Version(x => x.Version);
                Cache.ReadWrite().IncludeAll();
                HasMany(x => x.CaptionValues)
                    .KeyColumn("CaptionItem_Id")
                    .AsMap<string>(idx => idx.Column("CaptionSet_Name"), elem => elem.Columns.Add("Text", c => c.Length(10000)))
                    .Not.LazyLoad()
                    .Cascade.Delete()
                    .Table("CaptionValue")
                    .Cache.ReadWrite().IncludeAll();
