    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Runtime;
    using Android.Views;
    using Android.Widget;
    using Newtonsoft.Json;
    using NovaAndroid.Model;
    namespace NovaAndroid
    {
    [Activity(Label = "Prikaz detalja kupci")]
    public class AddEditActivity : Activity
    {
        EditText txtacSubject, txtacAddress, txtEmail, 
    txtPib,txtCountry,txtName,txtPhone,txtacRegNo,txtanRebate;
        Button btnBack;
        the_SetSubjModel model = new the_SetSubjModel();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddEditToDoItem);
            txtacSubject = FindViewById<EditText>(Resource.Id.addEdit_acSubject);
            txtacAddress = FindViewById<EditText>(Resource.Id.addEdit_address);
            txtEmail = FindViewById<EditText>(Resource.Id.addEdit_email);
            txtPib = FindViewById<EditText>(Resource.Id.addEdit_PIB);
            txtCountry= FindViewById<EditText>(Resource.Id.addEdit_acCountry);
            txtName = FindViewById<EditText>(Resource.Id.addEdit_acName2);
            txtPhone = FindViewById<EditText>(Resource.Id.addEdit_acPhone);
            txtacRegNo = FindViewById<EditText>(Resource.Id.addEdit_acRegNo);
            txtanRebate = FindViewById<EditText>(Resource.Id.addEdit_anRebate);
            btnBack = FindViewById<Button>(Resource.Id.addEdit_btnBack);
            btnBack.Click += BtnBack_Click; 
            string acSubject = Intent.GetStringExtra("acSubject") ?? 
    string.Empty;
            string acAddress = Intent.GetStringExtra("acAddress") ?? 
    string.Empty;
            string editMail = Intent.GetStringExtra("acPost") ?? string.Empty;
            string editPib = Intent.GetStringExtra("acCode") ?? string.Empty;
            string editCountry = Intent.GetStringExtra("acCountry") ?? 
    string.Empty;
            string editacName2 = Intent.GetStringExtra("acName2") ?? 
    string.Empty;
            string editacPhone = Intent.GetStringExtra("acPhone") ?? 
    string.Empty;
            string editacRegNo = Intent.GetStringExtra("acRegNo") ?? 
    string.Empty;
            string editanRebate = Intent.GetStringExtra("anRebate") ?? 
    string.Empty;
            if (acSubject.Trim().Length > 0)
            {
                txtacSubject.Text = acSubject;
                txtacAddress.Text = acAddress;
                txtEmail.Text = editMail;
                txtPib.Text = editPib;
                txtCountry.Text = editCountry;
                txtName.Text = editacName2;
                txtPhone.Text = editacPhone;
                txtacRegNo.Text = editacRegNo;
                txtanRebate.Text = editanRebate;
            }
        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            var activityBack = new Intent(this, typeof(ToDoItemActivity));
            StartActivity(activityBack);
        }
     
    }
    }
