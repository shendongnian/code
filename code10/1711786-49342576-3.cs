        public static void MapRecursively(PartModel partModel, PartEntity partEntity)
        {
            EntityMap.EntityMapper.Map(partEntity.PartEntityInformation, partModel);
            if (partEntity.PartEntityInformation.ReplacedBy == null
                || partEntity.PartEntityInformation.ReplacedBy.Count == 0) return;
            for (var i = 0; i < partModel.ReplacedBy.Count; i++)
            {
                MapRecursively(partModel.ReplacedBy[i], partEntity.PartEntityInformation.ReplacedBy[i]);
            }
        }
