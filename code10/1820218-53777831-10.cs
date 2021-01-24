    public class Reviewer : IComparable<Reviewer> {
      public int ReviewerID { get; set; }
      public string ReviewerName { get; set; }
      public Reviewer() {
      }
      public Reviewer(int reviewerID, string reviewerName) {
        ReviewerID = reviewerID;
        ReviewerName = reviewerName;
      }
      public override string ToString() {
        return "ReviewerID: " + ReviewerID.ToString();
      }
      public override bool Equals(object obj) {
        return this.ReviewerName.Equals(((Reviewer)obj).ReviewerName);
      }
      public override int GetHashCode() {
        return ReviewerName.GetHashCode();
      }
      public int CompareTo(Reviewer other) {
        return this.ReviewerID.CompareTo(other.ReviewerID);
      }
    }
