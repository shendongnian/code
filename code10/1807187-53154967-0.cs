    [Fact]
    public void TestJTokenBoolean2()
    {
        var token = JToken.Parse("true");
        token.Type.Should().Be(JTokenType.Boolean);
        JToken token2 = null;
        using (var stringWriter = new StringWriter())
        {
            token.WriteTo(new JsonTextWriter(stringWriter));
            Action deserialize = () => token2 = JToken.Parse(stringWriter.ToString());
            deserialize.Should().NotThrow();
            token2.Type.Should().Be(JTokenType.Boolean);
        }
    }
