	using System;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Input;
	using System.Windows.Media;
	using System.Windows.Media.Animation;
	using System.Windows.Shapes;
	namespace AnimationCompletedTest {
		public partial class MainWindow : Window {
			Canvas panel;
			public MainWindow() {
				InitializeComponent();
				MouseDown += DoDynamicAnimation;
				Content = panel = new Canvas();
			}
			void DoDynamicAnimation(object sender, MouseButtonEventArgs args) {
				for (int i = 0; i < 12; ++i) {
					var e = new Ellipse { Width = 16, Height = 16, Fill = SystemColors.HighlightBrush };
					Canvas.SetLeft(e, Mouse.GetPosition(this).X);
					Canvas.SetTop(e, Mouse.GetPosition(this).Y);
					var tg = new TransformGroup();
					var translation = new TranslateTransform(30, 0);
					var translationName = "myTranslation" + translation.GetHashCode();
					RegisterName(translationName, translation);
					tg.Children.Add(translation);
					tg.Children.Add(new RotateTransform(i * 30));
					e.RenderTransform = tg;
					panel.Children.Add(e);
					var anim = new DoubleAnimation(3, 100, new Duration(new TimeSpan(0, 0, 0, 1, 0))) {
						EasingFunction = new PowerEase { EasingMode = EasingMode.EaseOut }
					};
					var s = new Storyboard();
					Storyboard.SetTargetName(s, translationName);
					Storyboard.SetTargetProperty(s, new PropertyPath(TranslateTransform.YProperty));
					var storyboardName = "s" + s.GetHashCode();
					Resources.Add(storyboardName, s);
					s.Children.Add(anim);
					s.Completed +=
						(sndr, evtArgs) => {
							panel.Children.Remove(e);
							Resources.Remove(storyboardName);
							UnregisterName(translationName);
						};
					s.Begin();
				}
			}
			[STAThread]
			public static void Main() {
				var app = new Application();
				app.Run(new MainWindow());
			}
		}
	}
