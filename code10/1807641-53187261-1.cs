        // GET: api/sp_fc_ModelList_test_Result
        [Route("api/LinkedParts/All")]
        public Object GetAll()
        {
            var models = db
                .fc_Models
                .Include("fc_LinkParts")
                .Select(t => new ModelDto()
                {
                    ModelSeq = t.ModelSeq,
                    ModelId = t.ModelId,
                    EntityType = "Model",
                    ModelDescription = t.ModelDesc,
                    Manufacturer = t.Manufacturer,
                    PartList = t.fc_LinkParts.Select(p => new PartDto()
                    {
                        EntityType = "Part",
                        ModelId = p.ModelSeq,
                        SKU = p.PartNum,
                        Description = p.PartDescription,
                        Manufacturer = p.Manufacturer,
                        Class = (from d in db.PartClasses
                            where d.ClassID == p.PartClass
                            select d.Description).FirstOrDefault()
                    })
                });
            return models;
        }
