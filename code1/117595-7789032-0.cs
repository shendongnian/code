	public class AbbreviatedForDrawRecord {
		public int DrawId { get; set; }
		public long Member_Id { get; set; }
		public string FactorySerial { get; set; }
		public AbbreviatedForDrawRecord() {
		}
		public AbbreviatedForDrawRecord(int drawId, long memberId, string factorySerial) {
			this.DrawId = drawId;
			this.Member_Id = memberId;
			this.FactorySerial = factorySerial;
		}
	}
