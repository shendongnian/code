    public partial class Controls_ProductList : System.Web.UI.UserControl
    {
    	public int StallID { get; set; }
    	bool[] rowChanged;
    	bool[] rowDeleted;
    
    	// this allows me to test your code without your data source (C# 3.0 list constructor)
    	private static List<Product> _productList = new List<Product>() { 
    			new Product() { productID = 1, productName = "Product 1", productDesc = "This is product 1", productPrice = 1.0m },
    			new Product() { productID = 2, productName = "Product 2", productDesc = "This is product 2", productPrice = 1.0m },
    			new Product() { productID = 3, productName = "Product 3", productDesc = "This is product 3", productPrice = 1.0m }
    		};
    
    	protected void Page_Load(object sender, EventArgs e)
    	{
    		if (IsPostBack)
    		{
    			StallID = Convert.ToInt16(ViewState["StallID"].ToString());
    		}
    		else
    		{
    			// Only bind if this is not a postback
    			BindList();
    		}
    
    		int totalRows = ProductList.Rows.Count;
    		rowChanged = new bool[totalRows];
    		rowDeleted = new bool[totalRows];
    
    		ViewState.Add("StallID", StallID);
    
    		foreach (GridViewRow row in ProductList.Rows)
    		{
    			var checkBox = row.FindControl("cbDelete");
    			ScriptManager1.RegisterAsyncPostBackControl(checkBox);
    		}
    	}
    
    	public void BindList()
    	{
    		//StallHandler handler = new StallHandler();
    		//DataTable productList = handler.GetProductsByID(StallID);
    		ProductList.DataSource = _productList;
    		ProductList.DataBind();
    	}
    
    	protected void TextBox_TextChanged(object sender, EventArgs e)
    	{
    		TextBox thisTextBox = (TextBox)sender;
    		GridViewRow thisGridViewRow = (GridViewRow)thisTextBox.Parent.Parent;
    		int row = thisGridViewRow.RowIndex;
    		rowChanged[row] = true;
    	}
    
    	protected void cbDelete_CheckedChanged(object sender, EventArgs e)
    	{
    		CheckBox thisCheckbox = (CheckBox)sender;
    		GridViewRow thisGridViewRow = (GridViewRow)thisCheckbox.Parent.Parent;
    		int row = thisGridViewRow.RowIndex;
    		rowDeleted[row] = true;
    	}
    
    	protected void Page_PreRender(object sender, EventArgs e)
    	{
    		//if (Page.IsPostBack)
    		//{
    		//	ProductList.DataBind();
    		//}
    	}
    
    	protected void ProductList_PageIndexChanged(object sender, EventArgs e)
    	{
    
    	}
    
    	protected void ProductList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    	{
    		ProductList.PageIndex = e.NewPageIndex;
    		ProductList.DataBind();
    	}
    
    	protected void AddBtn_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    	{
    		Response.Redirect("../StallHolder/AddProduct.aspx");
    	}
    
    	protected void DeleteBtn_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    	{
    		int totalRows = ProductList.Rows.Count;
    		for (int r = 0; r < totalRows; r++)
    		{
    			if (rowDeleted[r])
    			{
    				GridViewRow thisGridViewRow = ProductList.Rows[r];
    				HiddenField hf1 = (HiddenField)thisGridViewRow.FindControl("HiddenField1");
    				int ID = Convert.ToInt16(hf1.Value);
    				//StallHandler handler = new StallHandler();
    				//handler.DeleteProduct(Convert.ToInt16(ID));
    
    				_productList = _productList.Where(a => a.productID != ID).ToList();
    			}
    		}
    		BindList();
    	}
    
    	protected void SaveBtn_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    	{
    		int totalRows = ProductList.Rows.Count;
    		for (int r = 0; r < totalRows; r++)
    		{
    			if (rowChanged[r])
    			{
    				GridViewRow thisGridViewRow = ProductList.Rows[r];
    				HiddenField hf1 = (HiddenField)thisGridViewRow.FindControl("HiddenField1");
    				int ID = Convert.ToInt32(hf1.Value);
    				TextBox tbName = (TextBox)thisGridViewRow.FindControl("tbName");
    				string Name = tbName.Text;
    				TextBox tbDesc = (TextBox)thisGridViewRow.FindControl("tbDesc");
    				string Desc = tbDesc.Text;
    				TextBox tbPrice = (TextBox)thisGridViewRow.FindControl("tbPrice");
    				string Price = tbPrice.Text;
    				//Code to update the database!
    
    				var product = _productList.Where(a => a.productID == ID).First();
    				product.productName = Name;
    				product.productDesc = Desc;
    				product.productPrice = decimal.Parse(Price, System.Globalization.NumberStyles.Currency);
    			}
    		}
    		BindList();
    	}
    }
    
    public class Product
    {
    	public int productID { get; set; }
    	public string productName { get; set; }
    	public string productDesc { get; set; }
    	public decimal productPrice { get; set; }
    }
