    public class ContentModel
	{
		public int? Total { get; set; }
		public IEnumerable<ContentResultModel> Results { get; set; }
		public FullContentModel Result { get; set; } 
		public IEnumerable<PaginationModel> Pagination { get; set; }
		public IEnumerable<ContentCommentsModel> Comments { get; set; }
        public bool ShouldSerializePagination()
        {
            // don't serialize the Pagination property, when the list is empty
            return Pagination != null && Pagination.Count() > 0;
        }
	}
