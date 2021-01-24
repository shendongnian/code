        System.Diagnostics.Debug.WriteLine("NOTIFICATION RECEIVED", p.Data);
        var data = p.Data;
        DependencyService.Get<IToast>().DisplayTost("opened notifications");
        LoadApplication(new App(true, p));
    };
}
