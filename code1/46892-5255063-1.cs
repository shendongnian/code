    [TestClass]
    public class ZBase32EncoderTests
    {
        [TestMethod]
        public void Encoding_0_ReturnsFirstCharacter()
        {
            var result = ZBase32Encoder.Encode(0);
            result.ShouldEqual(ZBase32Encoder.AcceptedCharacters[0].ToString());
        }
        [TestMethod]
        public void Encoding_1_ReturnsSecondCharacter()
        {
            var result = ZBase32Encoder.Encode(1);
            result.ShouldEqual(ZBase32Encoder.AcceptedCharacters[1].ToString());
        }
        [TestMethod]
        public void Encoding_32_ReturnsSecondAndFirstValues()
        {
            var result = ZBase32Encoder.Encode(32);
            result.ShouldEqual(ZBase32Encoder.AcceptedCharacters[1].ToString() + ZBase32Encoder.AcceptedCharacters[0].ToString());
        }
        [TestMethod]
        public void Encoding_64_ReturnsThirdAndFirstValues()
        {
            var result = ZBase32Encoder.Encode(64);
            result.ShouldEqual(ZBase32Encoder.AcceptedCharacters[2].ToString() + ZBase32Encoder.AcceptedCharacters[0].ToString());
        }
        [TestMethod]
        public void Encoding_65_ReturnsThirdAndSecondValues()
        {
            var result = ZBase32Encoder.Encode(65);
            result.ShouldEqual(ZBase32Encoder.AcceptedCharacters[2].ToString() + ZBase32Encoder.AcceptedCharacters[1].ToString());
        }
        [TestMethod]
        public void Decoding_FirstCharacter_Returns_0()
        {
            var inputCharacter = ZBase32Encoder.AcceptedCharacters[0];
            var result = ZBase32Encoder.Decode(inputCharacter);
            result.ShouldEqual(0);
        }
        [TestMethod]
        public void Decoding_SecondCharacter_Returns_1()
        {
            var inputCharacter = ZBase32Encoder.AcceptedCharacters[1];
            var result = ZBase32Encoder.Decode(inputCharacter);
            result.ShouldEqual(1);
        }
        [TestMethod]
        public void Decoding_SecondAndFirstValues_Shows_32()
        {
            var inputCharacters = ZBase32Encoder.AcceptedCharacters[1].ToString() + ZBase32Encoder.AcceptedCharacters[0];
            var result = ZBase32Encoder.Decode(inputCharacters);
            result.ShouldEqual(32);
        }
        [TestMethod]
        public void Decoding_ThirdAndFirstCharacters_Shows_64()
        {
            var inputCharacters = ZBase32Encoder.AcceptedCharacters[2].ToString() + ZBase32Encoder.AcceptedCharacters[0];
            var result = ZBase32Encoder.Decode(inputCharacters);
            result.ShouldEqual(64);
        }
    }
