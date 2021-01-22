    Public ReadOnly Property Jobs As List(Of Service.Job)
      Get
        Disposable(Of IService).Use(Sub(Client) Jobs = Client.GetJobs(Me.Status))
      End Get
    End Property
