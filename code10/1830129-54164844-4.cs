        var serializerSettings = new JsonSerializerSettings
        {
            DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate,
        };
        var a1 = JsonConvert.DeserializeObject<A>("{}", serializerSettings);
        // The following succeeds
        Assert.IsTrue(a1.SomeArray.SequenceEqual(new int[] { 4, 6, 12 }));
        // Sime SomeArray is a globally shared pointer, this will modify all current and future instances of A!
        a1.SomeArray[0] = -999;
        var a2 = JsonConvert.DeserializeObject<A>("{}", serializerSettings);
        // The following now fails!
        Assert.IsTrue(a2.SomeArray.SequenceEqual(new int[] { 4, 6, 12 }));
