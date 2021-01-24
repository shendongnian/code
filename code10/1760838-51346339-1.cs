	public class DataStatusItem
	{
		public int DataItemID { get; set; }
		public int DataItemCurrentStatusID { get; set; }
		public int DataItemStatusID { get; set; }
		public DateTime DateEffective { get; set; }
	}
	[TestClass]
	public class UpdateProcessingTestController
	{
		static IEnumerable<object[]> DataStatusItemsTestSetup
		{
			get
			{
				return new[]
				{
					new object[]
					{
						new List<DataStatusItem>
						{
							new DataStatusItem { DataItemID = 1, DataItemCurrentStatusID = 1, DataItemStatusID = 1, DateEffective = DateTime.Now },
							new DataStatusItem { DataItemID = 2, DataItemCurrentStatusID = 2, DataItemStatusID = 2, DateEffective = DateTime.Now },
						},
						1, // brand
						2, // dataType
						3  // processingStatus
					}
				};
			}
		}
		[TestMethod]
		[DynamicData(nameof(DataStatusItemsTestSetup))]
		public void SetDataItems(List<DataStatusItem> dataStatusItems, int brand, int dataType, int processingStatus)
		{
			Assert.AreEqual(2, dataStatusItems.Count);
			Assert.AreEqual(1, brand);
			Assert.AreEqual(2, dataType);
			Assert.AreEqual(3, processingStatus);
		}
	}
