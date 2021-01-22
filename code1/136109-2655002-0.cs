    [Test]
    public void When_Building_Text_With_A_Dictionary_As_The_Attributes_It_Should_Map_Members_To_Keys()
    {
        IDictionary<string, object> ret = new Dictionary<string, object>();
        ret["elem1"] = true;
        ret["elem2"] = false;
        
        var nestedObj = new Dictionary<string, object>();
        nestedObj["nestedProp"] = 100;
        ret["elem3"] = nestedObj;
        
        var template = new StringTemplate("$elem1$ or $elem2$ and value: $elem3.nestedProp$");
        template.Attributes = ret;
        StringBuilder sb = new StringBuilder();
        StringWriter writer = new StringWriter(sb);
        template.Write(new NoIndentWriter(writer));
        writer.Flush();
        var renderedText = sb.ToString();
        Assert.That(renderedText, Is.EqualTo("True or False and value: 100"));
    }
