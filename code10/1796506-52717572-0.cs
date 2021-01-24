    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Timers;
    using System.Windows.Forms;
    
    namespace Game
    {
        public partial class Form1 : Form
        {
            Player player;
            Obsticle obsticle;
    
            Thread UpdateThread;
    
            public const int Gravity = 1;
    
            public Form1()
            {
                InitializeComponent();
                InitializeObjects();
    
                UpdateThread = new Thread(() => {
                    System.Timers.Timer UpdateTimer = new System.Timers.Timer();
                    UpdateTimer.Elapsed += new System.Timers.ElapsedEventHandler(Update);
                    UpdateTimer.Interval = 2;
                    UpdateTimer.Enabled = true;                
                });
                UpdateThread.Start();
            }
    
            private void InitializeObjects()
            {
                PictureBox pb = new PictureBox();
                pb.BackgroundImage = global::Game.Properties.Resources.SuperMario;
                pb.BackgroundImageLayout = ImageLayout.Stretch;
                pb.Location = new Point(47, 59);
                pb.Name = "Player";
                pb.Size = new Size(76, 72);
                pb.TabIndex = 0;
                pb.TabStop = false;
                player = new Player(this, pb);
    
                PictureBox pb1 = new PictureBox();
                pb1.BackgroundImage = global::Game.Properties.Resources.Box;
                pb1.BackgroundImageLayout = ImageLayout.Stretch;
                pb1.Location = new Point(47, 226);
                pb1.Name = "Obsticle";
                pb1.Size = new Size(100, 95);
                pb1.TabIndex = 0;
                pb1.TabStop = false;
                obsticle = new Obsticle(this, pb1);
            }
            private void Update(object sender, ElapsedEventArgs e)
            {
                player.ApplyGravity(Gravity);
            }
    
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                
                player.Collider.DrawCollider(e.Graphics);
                obsticle.Collider.DrawCollider(e.Graphics);
            }
        }
    
        public class Object
        {
            public static List<Object> Objects = new List<Object>();
    
            public Form Handler;
            public PictureBox Picture { get; set; }
            public BoxCollider Collider { get; set; }
    
            public int x
            {
                get
                {
                    return _x;
                }
                set
                {
                    _x = value;
                    Handler.Invoke(new Action(() => {
                        Picture.Location = new Point((int)_x, Picture.Location.Y);
                        Handler.Refresh();
                    }));
                }
            }
            public int y
            {
                get
                {
                    return _y;
                }
                set
                {
                    _y = value;
                    Handler.Invoke(new Action(() => {
                        Picture.Location = new Point(Picture.Location.X, _y);
                        Handler.Refresh();
                    }));
                }
            }
    
            private int _x;
            private int _y;
    
            public Object(Form handler, PictureBox Picture)
            {
                this.Handler = handler;
                this.Picture = Picture;
    
                _x = Picture.Location.X;
                _y = Picture.Location.Y;
    
                handler.Controls.Add(Picture);
    
                Collider = new BoxCollider(this);
    
                Objects.Add(this);
            }
    
            public void ApplyGravity(int gravityForce)
            {
                if (Collider.CheckCollide())
                    return;
                y += gravityForce;
            }
        }
        public class Player : Object
        {
            public int movementSpeed { get { return _movementSpeed; } }
            private int _movementSpeed = 10;
    
            public Player(Form handler, PictureBox Picture) : base(handler, Picture)
            {
            }
    
            public void MoveDown(int value)
            {
                y += value;
            }
        }
        public class Obsticle : Object
        {
            public Obsticle(Form handler, PictureBox Picture) : base(handler, Picture)
            {
            }
        }
    
        public class BoxCollider
        {
            private Pen Pen_Default = new Pen(Color.Red);
            private Object Object;
            private Rectangle rect;
    
            public BoxCollider(Object Object)
            {
                this.Object = Object;
            }
    
            public bool CheckCollide()
            {
                foreach(Object o in Object.Objects)
                {
                    if (rect.IntersectsWith(o.Collider.rect) && o.Collider.rect != rect)
                        return true;
                }
                return false;
            }
    
            public void DrawCollider(Graphics g)
            {
                rect = new Rectangle(Object.Picture.Location.X, Object.Picture.Location.Y, Object.Picture.Width, Object.Picture.Height);
                Pen_Default.Width = 5;
                g.DrawRectangle(Pen_Default, rect);
            }
        }
    }
