    public class JobImageAuditViewModel : INotifyPropertyChanged {
      IEnumerable<Image> images;
      IEnumerable<Audit> audits;
      IEnumerable<JobImageAudit> jobImageAudits;
      public void GetData() {
         this.images = null;
         this.audits = null;
         this.jobImageAudits = null;
         OnPropertyChanged("JobImageAuditList");
         // Load images by using GetImageByIDQuery()
         // Load audits by using GetAuditByJobIDQuery()
      }
      void LoadImageCompleted(Object sender, EventArgs e) {
        // Store result of query.
        this.images = ...
        UpdateJobImageAuditList();
      }
      void LoadAuditCompleted(Object sender, EventArgs e) {
        // Store result of query.
        this.audits = ...
        UpdateJobImageAudits();
      }
      void UpdateJobImageAudits() {
        if (this.images != null && this.jobs != null) {
          // Combine images and audits.
          this.jobImageAudits = ...
          OnPropertyChanged("JobImageAudits");
        }
      }
      public IEnumerable<JobImageAudit> JobImageAudits {
        get {
          return this.jobImageAudits; 
        }
      }
      public event PropertyChangedEventHandler PropertyChanged;
      protected virtual void OnPropertyChanged(String propertyName) {
        var handler = PropertyChanged;
        if (handler != null)
          handler(this, new PropertyChangedEventArgs(propertyName));
      }
    }
