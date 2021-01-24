    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        View rootView = inflater.Inflate(Resource.Layout.Category1, container, false);
        txtCat1Name = (EditText)rootView.FindViewById(Resource.Id.txtCat1Name);
        txtCat1Length = (EditText)rootView.FindViewById(Resource.Id.txtCat1Length);
        txtCat1Line = (EditText)rootView.FindViewById(Resource.Id.txtCat1Line);
        btnSaveCat1 = (Button)rootView.FindViewById(Resource.Id.btnSaveCat1);
        rootLayout = rootView.FindViewById<LinearLayout>(Resource.Id.root_layout);
        btnSaveCat1.Click += btnSaveCat1_click;
        txtCat1Line.KeyPress += txtCat1Line_KeyPress;
        return rootView;
    }
    
    private void txtCat1Line_KeyPress(object sender, View.KeyEventArgs e)
        {
            e.Handled = false;
            if (TextUtils.IsEmpty(txtCat1Line .Text))
            {
                return;
            }
            noOfLine = Int16.Parse(txtCat1Line .Text);
            if (e.Event.Action == KeyEventActions.Down && e.KeyCode == Keycode.Enter)
            {
                for (int i = 0; i < noOfLine; i++)
                {
                    var spinner = new Spinner(this.Activity);
                    layout.AddView(spinner);
                    e.Handled = true;
                }
            }
        }
