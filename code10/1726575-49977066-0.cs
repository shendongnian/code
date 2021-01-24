    if (!String.IsNullOrEmpty(Intent.GetStringExtra(Intent.ExtraText)))
            {
                string subject = Intent.GetStringExtra(Intent.ExtraSubject) ?? "subject not available";
                Toast.MakeText(this, subject, ToastLength.Long).Show();
            }
