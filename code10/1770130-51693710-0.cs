    public class ModelOfWhateverJsonShouldLookLike
    {
        public float aNumber { get; set; }
        public string aString { get; set; }
        public bool isThisObjectNice { get; set; }
    }
    public static ToJsonModel(LinkingClass linkingObject, OtherLink otherLinkObject)
    {
        return new ModelOfWhateverJsonShouldLookLike
        {
            aNumber = linkingObject.aNumber, // otherLinkObject.aNumber?
            aString = linkingObject.aString,
            isThisObjectNice = otherLinkObject.isThisObjectNice
        };
    }
