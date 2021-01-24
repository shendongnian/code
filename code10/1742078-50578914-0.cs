        public override void OnReceive(Context context, Intent intent)
        {
            base.OnReceive(context, intent);
            var data = intent.GetStringExtra("alltotale");
            if(data != null)
            {
                var updateViews = new RemoteViews(context.PackageName, Resource.Layout.widget);
                SetTextViewText(updateViews, intent);
                // Push update for this widget to the home screen
                ComponentName thisWidget = new ComponentName(context, Java.Lang.Class.FromType(typeof(MyWidget)).Name);
                AppWidgetManager manager = AppWidgetManager.GetInstance(context);
                manager.UpdateAppWidget(thisWidget, updateViews);
            }
        }
        private void SetTextViewText(RemoteViews widgetView, Intent intent)
        {
            string oo = intent.GetStringExtra("alltotale");
            widgetView.SetTextViewText(Resource.Id.widgetMedium, "Dabboussi");
            widgetView.SetTextViewText(Resource.Id.widgetSmall, oo);
        }
