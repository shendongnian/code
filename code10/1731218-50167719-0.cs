	using System.Collections;
	using System.Collections.ObjectModel;
	using System.ComponentModel;
	using System.Linq;
	using System.Runtime.CompilerServices;
	using System.Windows;
	namespace DataBindingBitArray
	{
		/// <summary>
		/// 1. Create an Item class to track the status of each bit in the array. 
		/// </summary>
		/// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
		public class Item : INotifyPropertyChanged
		{
			public event PropertyChangedEventHandler PropertyChanged;
			public int BitArrayIndex { get; set; }
			public BitArray ParentBitArray { get; set; }
			private bool isChecked;
			public Item(int bitArrayIndex, bool isChecked, BitArray parentBitArray)
			{
				this.BitArrayIndex = bitArrayIndex;
				this.isChecked = isChecked;
				this.ParentBitArray = parentBitArray;
			}
			public bool IsChecked
			{
				get => isChecked;
				set
				{
					if (ParentBitArray != null)
					{
						ParentBitArray[BitArrayIndex] = isChecked = value;
						OnPropertyChanged(nameof(IsChecked));
					}
				}
			}
			private void OnPropertyChanged([CallerMemberName] string propertyName = null)
			{
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		/// <summary>
		/// 2. Create a MVVM view model with an observable collection of your Item object
		/// </summary>
		/// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
		public class BitArrayViewModel : INotifyPropertyChanged
		{
			private readonly BitArray bitArray;
			private ObservableCollection<Item> items;
			public event PropertyChangedEventHandler PropertyChanged;
			public ObservableCollection<Item> Items
			{
				get => items;
				set
				{
					items = value;
					OnPropertyChanged(nameof(Items));
				}
			}
			public BitArrayViewModel(BitArray bitArray)
			{
				this.bitArray = bitArray;
				var query = this
					.bitArray
					.Cast<bool>()
					.Select((s, i) => new Item(i, s, this.bitArray));
				this.Items = new ObservableCollection<Item>(query);
			}
			public int CountOnBits()
			{
				return this.bitArray.Cast<bool>().Count(s => s);
			}
			public int CountOffBits()
			{
				return this.bitArray.Cast<bool>().Count(s => !s);
			}
			protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
			{
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		/// <summary>
		/// 3 . Databind your view model in code behind
		/// </summary>
		/// <seealso cref="System.Windows.Window" />
		/// <seealso cref="System.Windows.Markup.IComponentConnector" />
		public partial class MainWindow : Window
		{
			public BitArrayViewModel ViewModel;
			public MainWindow()
			{
				InitializeComponent();
				this.DataContext = ViewModel = new BitArrayViewModel(new BitArray(100));
				MessageBox.Show($"You have {ViewModel.CountOnBits()} on bits and {ViewModel.CountOffBits()} off bits");
			}
			private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
			{
				MessageBox.Show($"You have {ViewModel.CountOnBits()} on bits and {ViewModel.CountOffBits()} off bits");
			}
		}
	}
