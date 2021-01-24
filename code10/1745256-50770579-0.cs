      public partial class Form1 : Form
      {
        private EntityBuffer _buffer = new EntityBuffer();
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnRedo;
    
        public Form1()
        {
          this.btnUndo = new System.Windows.Forms.Button();
          this.btnRedo = new System.Windows.Forms.Button();
          this.SuspendLayout();
    
          this.btnUndo.Location = new System.Drawing.Point(563, 44);
          this.btnUndo.Name = "btnUndo";
          this.btnUndo.Size = new System.Drawing.Size(116, 29);
          this.btnUndo.TabIndex = 0;
          this.btnUndo.Text = "Undo";
          this.btnUndo.UseVisualStyleBackColor = true;
          this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
    
          this.btnRedo.Location = new System.Drawing.Point(563, 79);
          this.btnRedo.Name = "btnRedo";
          this.btnRedo.Size = new System.Drawing.Size(116, 29);
          this.btnRedo.TabIndex = 0;
          this.btnRedo.Text = "Redo";
          this.btnRedo.UseVisualStyleBackColor = true;
          this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
    
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(800, 450);
          this.Controls.Add(this.btnRedo);
          this.Controls.Add(this.btnUndo);
          this.Name = "Form1";
          this.Text = "Form1";
          this.ResumeLayout(false);
        }
    
        protected override void OnLoad(EventArgs e)
        {
          _buffer.Add(new Rectangle(10, 10, 10, 10, Color.Red));
          _buffer.Add(new Rectangle(20, 20, 10, 10, Color.Red));
          _buffer.Add(new Rectangle(30, 30, 10, 10, Color.Red));
          _buffer.Add(new Text(40, 40, "Test", Color.Black));
          _buffer.Add(new Rectangle(50, 50, 10, 10, Color.Red));
          _buffer.Add(new Text(60, 60, "Test", Color.Black));
          base.OnLoad(e);
        }
    
        protected override void OnPaint(PaintEventArgs e)
        {
          foreach (var entity in _buffer.Entities)
            entity.Draw(e.Graphics);
    
          base.OnPaint(e);
        }
    
        private void btnUndo_Click(object sender, EventArgs e)
        {
          if (!_buffer.CanUndo)
            return;
          _buffer.Undo();
          Invalidate();
        }
    
        private void btnRedo_Click(object sender, EventArgs e)
        {
          if (!_buffer.CanRedo)
            return;
          _buffer.Redo();
          Invalidate();
        }
      }
    
      public abstract class Entity
      {
        public int X { get; set; }
        public int Y { get; set; }
        public Color Color { get; set; }
    
        public abstract void Draw(Graphics g);
    
        public Entity(int x, int y, Color color)
        {
          X = x;
          Y = y;
          Color = color;
        }
      }
    
      public class Text : Entity
      {
        private static Font _font = new Font(new FontFamily("Calibri"), 12, FontStyle.Regular, GraphicsUnit.Point);
        public string Value { get; set; }
    
        public Text(int x, int y, string value, Color color) : base(x,y,color) => Value = value;
    
        public override void Draw(Graphics g) => g.DrawString(Value, _font, new SolidBrush(Color), new PointF(X, Y));
      }
    
      public abstract class Shape : Entity
      {
        public int Width { get; set; }
        public int Height { get; set; }
        public Pen Pen { get; set; }
    
        public Shape(int x, int y, int width, int height, Color color) : base(x, y, color)
        {
          Width = width;
          Height = height;
        }
      }
    
      public class Rectangle : Shape
      {
        public Rectangle(Point start, Point end, Color color) : this(start.X, start.Y, end.X, end.Y, color) { }
        public Rectangle(int x, int y, int width, int height, Color color) : base(x, y, width, height, color) { }
    
        public override void Draw(Graphics g) => g.DrawRectangle(new Pen(new SolidBrush(Color)), X, Y, Width, Height);
      }
    
      public class EntityBuffer
      {
        public Stack<Entity> Entities { get; set; } = new Stack<Entity>();
        public Stack<Entity> RedoBuffer { get; set; } = new Stack<Entity>();
        public bool CanRedo => RedoBuffer.Count > 0;
        public bool CanUndo => Entities.Count > 0;
    
        public void Add(Entity entity)
        {
          Entities.Push(entity);
          RedoBuffer.Clear();
        }
    
        public void Undo() => RedoBuffer.Push(Entities.Pop());
        public void Redo() => Entities.Push(RedoBuffer.Pop());
      }
