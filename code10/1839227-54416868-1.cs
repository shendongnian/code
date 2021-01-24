    var data = new List<ResourceTier> {
        new ResourceTier{ Id=1, ParentId=0,  Volume=0, UnitRate=0, TotalPrice=0    },
        new ResourceTier{ Id=2, ParentId=0,  Volume=0, UnitRate=0, TotalPrice=0    },
        new ResourceTier{ Id=3, ParentId=1,  Volume=0, UnitRate=0, TotalPrice=0    },
        new ResourceTier{ Id=4, ParentId=1,  Volume=5, UnitRate=10, TotalPrice=0    },
        new ResourceTier{ Id=5, ParentId=2,  Volume=3, UnitRate=10, TotalPrice=0    },
        new ResourceTier{ Id=6, ParentId=3,  Volume=0, UnitRate=0, TotalPrice=0    },
        new ResourceTier{ Id=7, ParentId=3,  Volume=2, UnitRate=40, TotalPrice=0    },
        new ResourceTier{ Id=8, ParentId=6,  Volume=4, UnitRate=10, TotalPrice=0    },
        new ResourceTier{ Id=9, ParentId=6,  Volume=1, UnitRate=10, TotalPrice=0    },
    };
    var result = data.Select(x=>new ResourceTier { Id=x.Id, ParentId=x.ParentId, UnitRate=x.UnitRate, Volume=x.Volume, TotalPrice= total(x, data) }).ToList();
