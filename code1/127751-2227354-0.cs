    [TestFixture]
    public class When_working_with_nested_documents
    {
        [Test]
        public void Should_be_able_to_fetch_properties_of_nested_objects()
        {
            var mongo = new Mongo();
            mongo.Connect();
            var db = mongo.getDB("tests");
            var people = db.GetCollection("people");
            var jimi = new Document();
            jimi["Firstname"] = "Jimi";
            jimi["Lastname"] = "James";
            jimi["Pets"] = new[]
            {
                new Document().Append("Type", "Cat").Append("Name", "Fluffy"),
                new Document().Append("Type", "Dog").Append("Name", "Barky"),
                new Document().Append("Type", "Gorilla").Append("Name", "Bananas"),
            };
            people.Insert(jimi);
            var query = new Document();
            query["Pets.Type"] = "Cat";
            var personResult = people.FindOne(query);
            Assert.IsNotNull(personResult);
            var petsResult = (Document[])personResult["Pets"];
            var pet = petsResult.FindOne("Type", "Cat");
            Assert.IsNotNull(pet);
            Assert.AreEqual("Fluffy", pet["Name"]);
        }
    }
    public static class DocumentExtensions
    {
        public static Document FindOne(this Document[] documents, string key, string value)
        {
            foreach(var document in documents)
            {
                var v = document[key];
                if (v != null && v.Equals(value))
                {
                    return document;
                }
            }
            return null;
        }
    }
