    double tr[15];
    :
    tr[ 0] = 0; try { tr[ 0] = Double.Parse( t1.Text); } catch (Exception e) {};
    tr[ 1] = 0; try { tr[ 1] = Double.Parse( t2.Text); } catch (Exception e) {};
    :
    tr[14] = 0; try { tr[14] = Double.Parse(t15.Text); } catch (Exception e) {};
    :
    double total = 0;
    double sorf = 0;
    for (int i = 0; i < 15; i++) {
        if (tr[i] > 0) {
            sorf = sorf + tr[i];
            total++;
        }
    }
    :
