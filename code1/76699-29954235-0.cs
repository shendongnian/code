    private static void WriteObject(
            string fileName, IEnumerable<Vehichle> reflectedInstances, List<Type> knownTypeList)
        {
            using (FileStream writer = new FileStream(fileName, FileMode.Append))
            {
                foreach (var item in reflectedInstances)
                {
                    var serializer = new DataContractSerializer(typeof(Vehichle), knownTypeList);
                    serializer.WriteObject(writer, item);
                }
            }
        }
