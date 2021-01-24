       private static PartEntity GetPart()
        {
            var partEntityInfo = new PartEntityInformation
            {
                Name = "SomeName",
                Position = "2",
                ReplacedBy = new List<PartEntity>
                {
                    new PartEntity
                    {
                        PartNumber = "22",
                        PartEntityInformation = new PartEntityInformation
                        {
                            Name = "SomeSubName"
                        }
                    },
                    new PartEntity
                    {
                        PartNumber = "33",
                        PartEntityInformation = new PartEntityInformation
                        {
                            Name = "33SubName",
                            Position = "33SubPosition",
                            ReplacedBy = new List<PartEntity>
                            {
                                new PartEntity
                                {
                                    PartNumber = "444",
                                    PartEntityInformation = new PartEntityInformation
                                    {
                                        Name = "444SubSubname"
                                    }
                                }
                            }
                        }
                    }
                }
            };
            var part = new PartEntity
            {
                PartNumber = "1",
                PartEntityInformation = partEntityInfo
            };
            return part;
        }
