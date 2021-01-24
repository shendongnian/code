    using Google.Cloud.Firestore;
    
    namespace FirestoreTest.Models
    {
        [FirestoreData]
        public class ClassicGame
        {
            public ClassicGame()
            {
    
            }
    
            [FirestoreProperty]
            public string title { get; set; }
            [FirestoreProperty]
            public string publisher { get; set; }
        }
    }
