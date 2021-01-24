TableHeaderView 
    public class headerView : UIView
    {
        public headerView()
        {
            this.Frame = new CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, 50);
            nfloat width = UIScreen.MainScreen.Bounds.Width / 3;
            UILabel title = new UILabel();
            title.Text = "Title";
            title.TextColor = UIColor.Black;
            title.TextAlignment = UITextAlignment.Center;
            title.Font = UIFont.SystemFontOfSize(20);
            title.Layer.BorderColor = UIColor.Black.CGColor;
            title.Layer.BorderWidth = 1;
            title.Frame = new CGRect(0, 0, width, 50);
            this.Add(title);
            UILabel File = new UILabel();
            File.Text = "File";
            File.TextColor = UIColor.Black;
            File.TextAlignment = UITextAlignment.Center;
            File.Font = UIFont.SystemFontOfSize(20);
            File.Layer.BorderColor = UIColor.Black.CGColor;
            File.Layer.BorderWidth = 1;
            File.Frame = new CGRect(width, 0, UIScreen.MainScreen.Bounds.Width / 3, 50);
            this.Add(File);
            UILabel Option = new UILabel();
            Option.Text = "Option";
            Option.TextColor = UIColor.Black;
            Option.TextAlignment = UITextAlignment.Center;
            Option.Font = UIFont.SystemFontOfSize(20);
            Option.Layer.BorderColor = UIColor.Black.CGColor;
            Option.Layer.BorderWidth = 1;
            Option.Frame = new CGRect(width * 2, 0, UIScreen.MainScreen.Bounds.Width / 3, 50);
            this.Add(Option);
        }
    }
    table.TableHeaderView = new headerView();
TableViewCell
    public CustomVegeCell (NSString cellId) : base (UITableViewCellStyle.Default, cellId)
		{
			SelectionStyle = UITableViewCellSelectionStyle.Gray;
            nfloat width = UIScreen.MainScreen.Bounds.Width / 3;
            UIView headingLabel = new UIView();
            headingLabel.Layer.BorderColor = UIColor.Black.CGColor;
            headingLabel.Layer.BorderWidth = 1;
            headingLabel.Frame = new CGRect(0, 0, width, 100);
            UIView subheadingLabel = new UIView();
            subheadingLabel.Layer.BorderColor = UIColor.Black.CGColor;
            subheadingLabel.Layer.BorderWidth = 1;
            subheadingLabel.Frame = new CGRect(width, 0, width, 100);
            UIView imageView = new UIView();
            imageView.Layer.BorderColor = UIColor.Black.CGColor;
            imageView.Layer.BorderWidth = 1;
            imageView.Frame = new CGRect(width *2, 0, width, 100);
            ContentView.Add (headingLabel);
			ContentView.Add (subheadingLabel);
			ContentView.Add (imageView);
            ///add additional control here
		}
        
