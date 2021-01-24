    using Android.App;
    using Android.OS;
    using Android.Views;
    using Android.Widget;
    using System.Collections.Generic;
    
    namespace App1
    {
        [Activity(MainLauncher = true)]
        public class MainActivity : Activity
        {
            private LinearLayout linearLayoutClear;
            //private CheckBox[] checkBoxes;
            private List<string> selectedFileList;
    
            protected override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
                SetContentView(Resource.Layout.activity_main);
    
                linearLayoutClear = FindViewById<LinearLayout>(Resource.Id.linearLayoutClear);
    
                DisplayData();
    
                btnGetAllChecked = FindViewById<Button>(Resource.Id.btnGetAllChecked);
                btnGetAllChecked.Click += (s, e) =>
                {
                    if(selectedFileList != null)
                    {
                        Android.Util.Log.Debug("App.MainActivity", "AllChecked: " + string.Join(", ", selectedFileList));
                    }
                };
            }
    
            private void DisplayData()
            {
                var fileList = GeneralFunc.GetAllFile();
    
                //checkBoxes = new CheckBox[0];
    
                for (int i = 0; i < fileList.Count(); i++)
                {
                    var checkBox = new CheckBox(this);
    
                    checkBox.Text = fileList[i].ST_filename;
                    checkBox.Id = i;
                    checkBox.LayoutParameters = new ViewGroup.LayoutParams(LinearLayout.LayoutParams.WrapContent, LinearLayout.LayoutParams.WrapContent);
    
                    checkBox.CheckedChange += CheckBox_CheckedChange;
    
                    //Array.Resize(ref checkBoxes, i + 1);
                    //checkBoxes[i] = checkBox;
    
                    linearLayoutClear.AddView(checkBox);
                }
            }
    
            private void CheckBox_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
            {
                if (sender is CheckBox)
                {
                    var checkbox = (CheckBox)sender;
    
                    string test = checkbox.Id.ToString();
                    string checkedName = checkbox.Text;
    
                    if (selectedFileList == null)
                    {
                        selectedFileList = new List<string>();
                    }
    
                    if (checkbox.Checked)
                    {
                        selectedFileList.Add(checkedName); //get selected checkbox put in list
                    }
                    else
                    {
                        selectedFileList.Remove(checkedName); //checkbox is not checked anymore so remove it from the list
                    }
                }
            }
        }
    }
