    public partial class Form1 : Form
    {
      private readonly Device _device;
      private readonly PacketBinder _packetBinder;
    
      public Form1()
      {
        InitializeComponent();
        _device = Device.GetInstance();
        _packetBinder = PacketBinder.GetInstance(listView1);
    
        var thread = new Thread(WritePackets);
        thread.IsBackground = true;
    
        thread.Start();
      }
    
      private void WritePackets()
      {
        Packet packet = null;
        int countOfPacketCaptures = 0;
        while ((packet = _device.GetNextPacket()) != null)
        {
          packet = _device.GetNextPacket();
          MyPacket tempPacket = null;
    
          if (packet is TCPPacket)
          {
            TCPPacket tcp = (TCPPacket)packet;
            tempPacket = MyPacket.GetInstance();
    
            tempPacket.PacketType = "TCP";
            tempPacket.SourceAddress = Convert.ToString(tcp.SourceAddress);
            tempPacket.DestinationAddress =
              Convert.ToString(tcp.DestinationAddress);
            tempPacket.SourcePort = Convert.ToString(tcp.SourcePort);
            tempPacket.DestinationPort = Convert.ToString(tcp.DestinationPort);
            tempPacket.PacketMessage = Convert.ToString(tcp.Data);
          }
          else if (packet is UDPPacket)
          {
    
            UDPPacket udp = (UDPPacket)packet;
    
    
            tempPacket = MyPacket.GetInstance();
    
            tempPacket.PacketType = "UDP";
            tempPacket.SourceAddress = Convert.ToString(udp.SourceAddress);
            tempPacket.DestinationAddress =
              Convert.ToString(udp.DestinationAddress);
            tempPacket.SourcePort = Convert.ToString(udp.SourcePort);
            tempPacket.DestinationPort = Convert.ToString(udp.DestinationPort);
            tempPacket.PacketMessage = Convert.ToString(udp.Data);
          }
    
          if (tempPacket != null)
          {
            _packetBinder.AddPacketToView(tempPacket);
          }
        }
      }
    }
    
    internal class Device
    {
      private Device() { }
    
      internal static Device GetInstance()
      {
        return new Device();
      }
    
      internal Packet GetNextPacket()
      {
        var random = new Random();
        var coin = random.Next(2);
    
        Thread.Sleep(500);
    
        if (coin == 0)
        {
          return new TCPPacket()
          {
            Data = GetRandomString(random),
            SourceAddress = GetRandomString(random),
            SourcePort = random.Next(),
            DestinationAddress = GetRandomString(random),
            DestinationPort = random.Next()
          };
        }
        else
        {
          return new UDPPacket()
          {
            Data = GetRandomString(random),
            SourceAddress = GetRandomString(random),
            SourcePort = random.Next(),
            DestinationAddress = GetRandomString(random),
            DestinationPort = random.Next()
          };
        }
      }
    
      private string GetRandomString(Random random)
      {
        var bytes = new byte[16];
        random.NextBytes(bytes);
    
        return Convert.ToBase64String(bytes);
      }
    }
    
    internal class MyPacket
    {
      private MyPacket() { }
    
      internal static MyPacket GetInstance()
      {
        return new MyPacket();
      }
    
      internal string PacketType { get; set; }
      internal string SourceAddress { get; set; }
      internal string DestinationAddress { get; set; }
      internal string SourcePort { get; set; }
      internal string DestinationPort { get; set; }
      internal string PacketMessage { get; set; }
    }
    
    internal class ThreadSafeListViewMutator
    {
      private readonly ListView _target;
    
      private ThreadSafeListViewMutator(ListView target)
      {
        _target = target;
      }
    
      internal static ThreadSafeListViewMutator GetInstance(ListView target)
      {
        return new ThreadSafeListViewMutator(target);
      }
    
      internal void AddListViewItem(ListViewItem listItem)
      {
        Action action = () => _target.Items.Add(listItem);
        Delegate asDelegate = action;
        var handle = _target.BeginInvoke(asDelegate);
        _target.EndInvoke(handle);
      }
    }
    
    internal class PacketBinder
    {
      private readonly ThreadSafeListViewMutator _target;
    
      private PacketBinder(ListView target)
      {
        _target = ThreadSafeListViewMutator.GetInstance(target);
      }
    
      internal static PacketBinder GetInstance(ListView target)
      {
        return new PacketBinder(target);
      }
    
      internal void AddPacketToView(MyPacket tempPacket)
      {
        var listItem = new ListViewItem() { Text = tempPacket.PacketType };
    
        AddSubItem(listItem, "From", tempPacket.SourceAddress + ":"
          + tempPacket.SourcePort);
        AddSubItem(listItem, "To", tempPacket.DestinationAddress + ":"
          + tempPacket.DestinationPort);
        AddSubItem(listItem, "Message", tempPacket.PacketMessage);
    
        _target.AddListViewItem(listItem);
      }
    
      private void AddSubItem(ListViewItem listItem, string attribute, string value)
      {
        listItem.Text = listItem.Text + @"
    " + attribute + " = " + value;
      }
    }
    
    internal class Packet { }
    
    // Are these really duplicated this way?  Seems crazy...
    internal class TCPPacket : Packet
    {
      internal string SourceAddress { get; set; }
      internal string DestinationAddress { get; set; }
      internal int SourcePort { get; set; }
      internal int DestinationPort { get; set; }
      internal string Data { get; set; }
    }
    
    internal class UDPPacket : Packet
    {
      internal string SourceAddress { get; set; }
      internal string DestinationAddress { get; set; }
      internal int SourcePort { get; set; }
      internal int DestinationPort { get; set; }
      internal string Data { get; set; }
    }
