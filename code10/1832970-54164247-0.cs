    public class TEST : MonoBehaviour {
    [SerializeField]
    Sprite m_InSprite;
    SerializeTexture exportObj = new SerializeTexture();
    SerializeTexture importObj = new SerializeTexture();
    [ContextMenu("serialize")]
    public void SerializeTest()
    {
        Texture2D tex = m_InSprite.texture;
        exportObj.x = tex.width;
        exportObj.y = tex.height;
        exportObj.bytes = ImageConversion.EncodeToPNG(tex);
        string text = JsonConvert.SerializeObject(exportObj);
        File.WriteAllText(@"d:\test.json", text);
    }
    [ContextMenu("deserialize")]
    public void DeSerializeTest()
    {
        string text = File.ReadAllText(@"d:\test.json");
        importObj = JsonConvert.DeserializeObject<SerializeTexture>(text);
        Texture2D tex = new Texture2D(importObj.x, importObj.y);
        ImageConversion.LoadImage(tex,importObj.bytes);
        Sprite mySprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), Vector2.one);
        GetComponent<Image>().sprite = mySprite;
    }
    [Serializable]
    public class SerializeTexture
    {
        [SerializeField]
        public int x;
        [SerializeField]
        public int y;
        [SerializeField]
        public byte[] bytes;
    }
}
