    using(MemoryStream ms = new MemoryStream(TestASettingsString)) {
        BinaryFormatter bf = new BinaryFormatter();
        TestASettings = (WhateverType)bf.Deserialize(ms);
    }
    using(MemoryStream ms = new MemoryStream(TestBSettingsString)) {
        BinaryFormatter bf = new BinaryFormatter();
        TestBSettings = (WhateverOtherType)bf.Deserialize(ms);
    }
