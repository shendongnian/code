        private static IEnumerable<Tuple<TestModel, TestModel>> FindSimilarModelPairs(TestModel[] models)
        {
            for(int i=0; i < models.Length; ++i)
            {
                TestModel model = models[i];
                // Skip the items already processed in the parent loop, to avoid duplicate pairs - if the sequence of two "similar" pairs is important, then the skip should not be done.
                foreach(TestModel innerModel in models.Skip(i+1).Where(m => model.IsSimilar(m)))
                {
                    yield return new Tuple<TestModel, TestModel>(model, innerModel);
                }
            }
        }
