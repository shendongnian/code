    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    
    namespace StackOverflow_DBG.ViewModels
    {
        public abstract class ViewModelBase : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    
            protected virtual bool SetAndRaisePropertyChanged<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
            {
                if (EqualityComparer<T>.Default.Equals(storage, value))
                    return false;
                storage = value;
                this.RaisePropertyChanged(propertyName);
                return true;
            }
        }
    
        public class RelayCommand : ICommand
        {
            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }
            private Action methodToExecute;
            private Func<bool> canExecuteEvaluator;
            public RelayCommand(Action methodToExecute, Func<bool> canExecuteEvaluator)
            {
                this.methodToExecute = methodToExecute;
                this.canExecuteEvaluator = canExecuteEvaluator;
            }
            public RelayCommand(Action methodToExecute)
                : this(methodToExecute, null)
            {
            }
            public bool CanExecute(object parameter)
            {
                if (this.canExecuteEvaluator == null)
                {
                    return true;
                }
                else
                {
                    bool result = this.canExecuteEvaluator.Invoke();
                    return result;
                }
            }
            public void Execute(object parameter)
            {
                this.methodToExecute.Invoke();
            }
        }
    
        class MainWindowViewModel : ViewModelBase
        {
            private String m_LabelTxt = "Foo";
            public String LabelTxt
            {
                get { return m_LabelTxt; }
                set => SetAndRaisePropertyChanged(ref m_LabelTxt, value);
            }
    
            private String m_ValueTxt;
            public String ValueTxt
            {
                get { return m_ValueTxt; }
                set => SetAndRaisePropertyChanged(ref m_ValueTxt, value);
            }
    
            private RelayCommand m_ChangeLabel;
            public RelayCommand ChangeLabel
            {
                get { return m_ChangeLabel; }
                set { m_ChangeLabel = value; }
            }
    
            public MainWindowViewModel()
            {
                ChangeLabel = new RelayCommand(() => {
                    if (LabelTxt == "Foo")
                    {
                        LabelTxt = "Bar ";
                    }
                    else
                    {
                        LabelTxt = "Foo ";
                    }
                });
            }
        }
    }
