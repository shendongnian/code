    [Serializable()]
    public class CCanvas
    {
    List<CDrawing> _listControls;
    public List<CDrawing> Controls
    {
        get { return _listControls; }
    }
    public CCanvas()
    {
        _listControls = new List<CDrawing>();
    }
    public void AddControls(CDrawing theControls)
    {
        _listControls.Add(theControls);
    }
    public void ReloadControl(Form frm)
    {
        //foreach (CDrawing draw in _listControls) -- requires IEnumerable implementation.
        for (int i = 0; i < _listControls.Count; i++)
        {
            CDrawing d = (CDrawing)_listControls[i];
            d.Draw(frm);
        }
    }
    public void Save()
    {
        try
        {
            using (Stream stream = File.Open("data.bin", FileMode.Create))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, this);
            }
        }
        catch (IOException)
        {
        }
    }
    public CCanvas Open()
    {
        CCanvas LoadedObj = null;
        using (Stream stream = File.Open("data.bin", FileMode.Open))
        {
            BinaryFormatter bin = new BinaryFormatter();
            LoadedObj = (CCanvas)bin.Deserialize(stream);
        }
        return LoadedObj;
    }
