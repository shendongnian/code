    
    public class ContainerElementCtrl : MonoBehaviour
    {
        public void SetData<T>(T tabData) where T : IData
        {
            Console.WriteLine("setData type " + typeof(T) + " " + tabData.Title);
        }
    }
    public interface IData
    {
        string Title { get; set; }
    }
    public class DataA : IData
    {
        public string Title { get; set; }
        public string PicUrl;
    }
    public class DataB : IData
    {
        public string Title { get; set; }
    }
    public class MainContainer : MonoBehaviour
    {
        public ContainerElementCtrl containerElement;
        public void setDataInUI<T>(T tabsData) where T : IData
        {
            containerElement.SetData(tabsData);
        }
    }
